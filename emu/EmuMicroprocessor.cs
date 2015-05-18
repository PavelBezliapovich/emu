using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emu
{
    class EmuMicroprocessor
    {
        public int ProgramMemorySize = 2048;
        public int DataMemorySize = 2048;
        public int RegistersCount = 32;

        public Int16[] Registers;
        public Int16[] ProgramMemory;
        public Byte[] DataMemory;
        public String[] SysRegNames = new String[] { "PC", "PCI", "CI", "CIA", "NI", "NIA", "F", "FI" };
        private String[]  _flags = new String[] { "Z", "I", "C", "U" };

        public static String[] Commands = new String[] {
             null ,"NOP", "INT", "ADD", "SUB", "DIV", "MUL", "MOV", "RET"
        };

        public EmuMicroprocessor()
        {
            
        }

        public void Init()
        {
            this.Registers = new Int16[this.RegistersCount + this.SysRegNames.Length];
            this.ProgramMemory = new Int16[this.ProgramMemorySize];
            this.DataMemory = new Byte[this.DataMemorySize];
        }

        public static int GetOpCodeByName(String Name)
        {
            return Array.IndexOf(EmuMicroprocessor.Commands, Name.ToUpper());
        }

        public static String GetNameByOpCode(int OpCode)
        {
            return EmuMicroprocessor.Commands[OpCode];
        }

        public static Int16[] GetOpcodeHEX(int OpCode, int[] Operands, int[] Types)
        {

            Int16[] r = new Int16[Math.Max(1,Operands.Length)];
            r[0] = (Int16)(OpCode << 10);
            if (Operands.Length > 0)
            {
                r[0] |= (Int16)(((0x3 & Types[0]) << 8) | (0x3F & Operands[0]));
            }
            if (Operands.Length == 2)
            {
                r[0] |= (Int16)((0x3 & Types[1]) << 6);
                r[1] |= (Int16)Operands[1];
            }

            return r;
        }

        public void Parse(String[] input)
        {
            int offset = 0;

            if (input.Length == 0)
            {
               // throw new CPUException("The code is empty.");
            }

            for (int i = 0; i < input.Length; i++)
            {
                String cur = input[i].Trim(new char[] { ' ', '\t', '\r', '\n' });
                if (cur.Length == 0 || cur[0] == '#' || (cur[0] == '/' && cur[1] == '/'))
                    continue;
                String[] cmd = cur.Replace("  ", " ").Replace(", ", ",").Split(new char[] { ' ', '\t', ',' });
                int OpCode = EmuMicroprocessor.GetOpCodeByName(cmd[0]);
                if (OpCode == -1)
                {
                    //throw new CPUException("Wrong opcode '" + cmd[0].ToUpper() + "' found at line #" + i.ToString() + ".");
                }
                int[] Operands = new int[cmd.Length - 1];
                int[] Types = new int[cmd.Length - 1];
                int[] Formats = new int[cmd.Length - 1];
                for (int j = 0; j < Operands.Length; j++)
                {
                    String op = cmd[1 + j];
                    switch (op[0])
                    {
                        case 'R':
                        case 'r':
                            Types[j] = 0x2;
                            break;
                        case '#':
                            op = op.Replace("#", "");
                            Types[j] = 0x3;
                            break;
                        default:
                            Types[j] = 0x1;
                            break;

                    }

                    op = op.Replace("R", "").Replace("r", "");
                    if (op[0] == 'x' || op[0] == 'X')
                    {
                        op = op.Replace("X", "").Replace("x", "");
                    }
                    try
                    {
                        Operands[j] = int.Parse(op);
                    }
                    catch (Exception)
                    {
                        //throw new CPUException("Cannot inerprete '" + op + "' at line " + i.ToString());
                    }
                }

                Int16[] cmx = EmuMicroprocessor.GetOpcodeHEX(OpCode, Operands, Types);

                for( int q = 0; q < cmx.Length; q++ )
                {
                    this.ProgramMemory[offset] = cmx[q];
                    offset++;
                }

            }
            return;
        }

        public void SetReg(Int16 id, Int16 value)
        {
            this.Registers[this.SysRegNames.Length + id] = value;
        }

        public Int16 GetReg(int id)
        {
            return this.Registers[this.SysRegNames.Length + id];
        }

        public void SetReg(String id, Int16 value)
        {
            this.Registers[Array.IndexOf(this.SysRegNames, id)] = value;
        }

        public Int16 GetReg(String id)
        {
            return this.Registers[Array.IndexOf(this.SysRegNames, id)];
        }

        Int16 GetOperandValue(Int16 op, Int16 type)
        {
            switch (type)
            {
                case 1:
                    return op;
                case 3:
                    return this.GetReg(this.GetReg(31)+op);
                case 2:
                    return this.GetReg(op);
            }
            return 0xCC; // error
        }

        public void SetFlag(String f, bool value)
        {
           int mask = 1 << Array.IndexOf(_flags, f);
           this.SetReg("F", (Int16)((this.GetReg("F") & ~mask) | mask));
        }

        public bool GetFlag(String f)
        {
           
            int mask = 1 << Array.IndexOf(_flags, f);
            return (this.GetReg("F") & mask) == mask;
        }

        public EmuMicroprocessorState NextStep()
        {
            var mpState = new EmuMicroprocessorState();
            Int16 offset = this.GetReg("PC");
            Int16 com = this.ProgramMemory[offset++];
            var OpCode = (Int16)(com >> 10);
            Int16 f0 = (Int16)(0x3 & (com >> 8));
            Int16 f1 = (Int16)(0x3 & (com >> 6));
            Int16 r0 = (Int16)(0x3F & com), v0 = this.GetOperandValue(r0,f0);
            Int16 r1 = 0, v1 = 0;
            if (f1 != 0)
            {
                r1 = this.ProgramMemory[offset++];
                v1 = this.GetOperandValue(r1, f1);
            }

            switch (EmuMicroprocessor.GetNameByOpCode(OpCode))
            {
                case "MOV":
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();

                    this.SetReg(r0, v1);
                    break;
                case "ADD":
                    this.SetReg(r0, (Int16)(v0 + v1));
                    this.SetFlag("Z", (v0 + v1) == 0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    break;
                case "SUB":
                    this.SetReg(r0, (Int16)(v0 - v1));
                    this.SetFlag("Z", (v0 - v1) == 0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    break;
                case "MUL":
                    this.SetReg(r0, (Int16)(v0 * v1));
                    this.SetFlag("Z", (v0 * v1) == 0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    break;
                case "DIV":
                    this.SetReg(r0, (Int16)(v0 / v1));
                    this.SetFlag("Z", (v0 / v1) == 0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    break;
                case "JMP":
                    this.SetReg("PC",v0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    mpState.Flag = false;
                    return mpState;
                case "JZ":
                    if (!this.GetFlag("Z"))
                        break;
                    this.SetReg("PC", v0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    mpState.Flag = false;
                    return mpState;
                case "JNZ":
                    if (this.GetFlag("Z"))
                        break;
                    this.SetReg("PC", v0);
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    mpState.Flag = false;
                    return mpState;
                case "RET":
                    mpState.PK = EmuMicroprocessor.GetNameByOpCode(OpCode);
                    mpState.BR1 = r0.ToString();
                    mpState.BR2 = r1.ToString();
                    mpState.EAXPP = v1.ToString();
                    mpState.Flag = true;
                    return mpState;
                case "NOP":
                    break;
               // default:
                    //throw new CPUException("Wrong opcode given");
            }

            this.SetReg("PC",offset);
            this.SetReg("CIA", offset);
            this.SetReg("CI", this.ProgramMemory[offset]);
            mpState.Flag = false;

            return mpState;
        }
    }
}
