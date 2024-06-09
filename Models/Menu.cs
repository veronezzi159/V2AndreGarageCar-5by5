using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Models
{
    public class Menu
    {

        public int ChamarMenu()
        {
            var stats = false;
            var op = 0;
            do
            {
                try
                {
                    Console.WriteLine(">>>>> MENU CARRO GARAGEM <<<<<");
                    Console.WriteLine("================================");
                    Console.WriteLine("[1] - VER CARROS VERMELHOS");
                    Console.WriteLine("[2] - CRIAR XML CARROS VERMELHOS");
                    Console.WriteLine("[3] - VER CARROS STATUS TRUE");
                    Console.WriteLine("[4] - CRIAR XML CARROS STATUS TRUE");
                    Console.WriteLine("[5] - VER CARROS FABRICADOS ENTRE 2010 E 2011");
                    Console.WriteLine("[6] - CRIAR XML CARROS FABRICADOS ENTRE 2010 E 2011");
                    Console.WriteLine("[0] - SAIR");
                    Console.WriteLine("================================");
                    Console.Write("OPÇÃO: ");
                    op = int.Parse(Console.ReadLine());
                    stats = true;
                }
                catch (Exception)
                {

                    throw;
                }
            } while (!stats);
            return op;
        }   
    }
}
