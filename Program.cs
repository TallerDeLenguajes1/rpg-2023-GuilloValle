// See https://aka.ms/new-console-template for more information
using CrearPersonaje;
using System.Text.Json;
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;



internal class Program
{
    private static void Main(string[] args)
    {

        var Personajes = new List<Personaje>();      //LISTA CON LOS PERSONAJES
        List<Personaje> ganadores = new List<Personaje>();
        var PersonajesJson1 = new PersonajesJson();  // INSTACIO LA CLASE PARA PODER USAR LOS METODOS
        Random random = new Random();                // INSTACIO LA CLASE PARA PODER USAR LOS METODOS


        if (PersonajesJson1.Existe("personajes.json"))
        {

            Personajes = PersonajesJson1.LeerPesonajes("personajes.json");
            // foreach (var personaje in Personajes)
            // {
            //     MostrarDatos(personaje);
            // }

        }
        else
        {
            CargarPesonajesALista(Personajes, 8);
            PersonajesJson1.GuardarPersonaje(Personajes, "personajes.json");
            // foreach (var personaje in Personajes)
            // {
            //     MostrarDatos(personaje);
            // }
        }

        /*---------------------------------------------------------------------------------------------------*/

        
           Root tipos1;
            var url = $"https://www.dnd5eapi.co/api/classes/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            //System.Console.WriteLine(responseBody);
                            tipos1   = JsonSerializer.Deserialize<Root>(responseBody);
                            
                            
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }
        
      
        /*---------------------------------------------------------------------------------------------------*/
       
        System.Console.WriteLine("----------------BIENVENIDOS A LA PELEA DEL SIGLO----------------");
        int ronda = 1;

        while (Personajes.Count > 1)
        {
            if (ronda == 1)
            {
                Console.WriteLine($"--- Ronda {ronda} , CUARTOS DE FINAL ---");
                Console.WriteLine();
            }
  
            if (ronda == 2)
            {
                Console.WriteLine($"--- Ronda {ronda} , SEMIFINALES ---");
                Console.WriteLine();
            }

            if (ronda == 3)
            {
                Console.WriteLine($"--- Ronda {ronda} , FINAL  ---");
                Console.WriteLine();
            }

            List<Personaje> proximosPersonajes = new List<Personaje>();

            while (Personajes.Count > 1)
            {
                Personaje personaje1 = ElegirPersonaje(Personajes, random);
                Personaje personaje2 = ElegirPersonaje(Personajes, random);

                Console.WriteLine($"{personaje1.Nombre} vs {personaje2.Nombre}");

                Personaje ganador = Lucha(personaje1, personaje2, random);

                Console.WriteLine($"Ganador: {ganador.Nombre}");
                Console.WriteLine();

                proximosPersonajes.Add(ganador);
            }
                
            if (Personajes.Count == 1)
            {
                Console.WriteLine($"Ganador de la Ronda {ronda}: {Personajes[0].Nombre}");
                Console.WriteLine();
            }

            Personajes = proximosPersonajes;
            ronda++;
            System.Console.WriteLine("PRESIONE ENTER PARA SEGUIR");
            Console.ReadKey();
            
        }
        
        

        Console.WriteLine($"El ganador del torneo es: {Personajes[0].Nombre}");
        

    }

    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(5); // Retardo de 100 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }

    private static Personaje ElegirPersonaje(List<Personaje> personajes, Random random)
    {
        int indice = random.Next(personajes.Count);
        Personaje personaje = personajes[indice];
        personajes.RemoveAt(indice);
        return personaje;
    }
    private static Personaje Lucha(Personaje p1,Personaje p2, Random random)
    {
        int i = 1;
        double ataque;
        double efectidad;
        double defensa;
        double DañoProvocado;
        int constanteDeAjuste = 100;


        while (p1.Salud > 0 && p2.Salud > 0)
        {
            if (i % 2 == 0)  //FORMA PARA QUE ATAQUE UNO A LA VEZ
            {
                ataque = p1.Destreza * p1.Fuerza * p1.Nivel + 20;
                efectidad = random.Next(1, 101);
                defensa = p2.Armadura * p2.Velocidad;

                DañoProvocado = ((ataque * efectidad) - defensa) / constanteDeAjuste;
                p2.Salud = p2.Salud - DañoProvocado;
                EscribirMensaje(p1.Nombre + " ATACA CON:" + poderes.poderesAtaque[random.Next(0, 10)]);
                EscribirMensaje("DAÑO REALIZADO: " + DañoProvocado.ToString("0.00"));
                EscribirMensaje("La vida de " + p2.Nombre + " es: " + p2.Salud.ToString("0.00"));

            }
            else
            {
                ataque = p2.Destreza * p2.Fuerza * p2.Nivel;
                efectidad = random.Next(1, 101);
                defensa = p1.Armadura * p1.Velocidad;

                DañoProvocado = ((ataque * efectidad) - defensa) / constanteDeAjuste;
                p1.Salud = p1.Salud - DañoProvocado;
                EscribirMensaje(p2.Nombre + " utiliza el poder de:" + poderes.poderesAtaque[random.Next(0, 10)]);
                EscribirMensaje("DAÑO REALIZADO: " + DañoProvocado.ToString("0.00"));
                EscribirMensaje("La vida de " + p1.Nombre + " es: " + p1.Salud.ToString("0.00"));
            }

            i++;
        }

        if (p2.Salud <= 0)
        {
            System.Console.WriteLine(p1.Nombre + " ES EL GANADOR");
            p1.Salud = 100;
            return p1;
        }
        else
        {
            System.Console.WriteLine(p2.Nombre + " ES EL GANADOR");
            p2.Salud = 100;
            return p2;
        }
    }

    private static void MostrarDatos(Personaje P)
    {
        Console.WriteLine("--Datos Personaje--");
        Console.WriteLine("Nombre:" + P.Nombre);
        Console.WriteLine("Edad:" + P.Edad);
        Console.WriteLine("Tipo: " + P.Tipo);
        Console.WriteLine("Fecha de Nacimiento:" + P.FechaDenacimiento.ToShortDateString());
    }

    private static void CargarPesonajesALista(List<Personaje> Personajes,int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            var nuevo = new fabricaDePersonajes();
            var personaje = nuevo.crearPersonaje();
            Personajes.Add(personaje);
        }
    }


}


