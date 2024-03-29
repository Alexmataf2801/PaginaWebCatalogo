﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilerias
{
    public class Utilerias
    {
        public static string GenerarPassword(int longitud)
        {
            string contrasena = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    contrasena += letras[LetraAleatoria];
                }
                else
                {
                    contrasena += NumeroAleatorio.ToString();
                }
            }
            return contrasena;
        }

        public static string Encriptar(string Texto)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(Texto);
            result = Convert.ToBase64String(encryted);
            return result;
        }


        public static string DesEncriptar(string Texto)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(Texto);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }




    }
}
