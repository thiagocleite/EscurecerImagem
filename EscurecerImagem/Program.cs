using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EscurecerImagem
{
    class Program
    {
        static void Main(string[] args)
        {
            int tam, pos;
            byte data;
            int bits = 0;
            int aux;
            int escurecer;

            FileStream fs = new FileStream("img.bmp", FileMode.Open, FileAccess.ReadWrite);

            fs.Seek(28, SeekOrigin.Current);
            for (int i = 0; i < 2; i++)
            {
                bits += fs.ReadByte();
            }

            if (bits <= 8)
            {
                tam = (14 + 40 + (4 * ((int)Math.Pow(2,bits))))-30;
            }
            else
            {
                tam = (int)fs.Length;
            }

            pos = 54;
            escurecer = 50;


            fs.Seek(pos, SeekOrigin.Current);

            Console.WriteLine("Processando");
            for (int i = pos; i < tam; i++)
            {
                pos = (int)fs.Position;
                data = (byte)fs.ReadByte();
                aux = (int)data;

                if (aux >= escurecer)
                    aux -= escurecer;
                else
                    aux -= aux;

                data = (byte)aux;
                fs.Position--;
                fs.WriteByte(data);
            }
            Console.WriteLine("terminou");
            Console.ReadKey();
        }
    }
}
