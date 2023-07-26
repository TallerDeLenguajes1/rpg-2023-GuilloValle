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

        var Personajes = new List<Personaje>();      
        List<Personaje> ganadores = new List<Personaje>();
        var PersonajesJson1 = new PersonajesJson();  
        Random random = new Random();                


        if (PersonajesJson1.Existe("personajes.json"))
        {

            Personajes = PersonajesJson1.LeerPesonajes("personajes.json");
        }
        else
        {   
            var classesNames = ClassesService.GetClassesNames();
            if (classesNames.Count() == 0 )
            {
                CargarPesonajesALista(Personajes, 8);
                PersonajesJson1.GuardarPersonaje(Personajes, "personajes.json");
                System.Console.WriteLine("1");   
            }else
            {             
                string json = JsonSerializer.Serialize(classesNames);
                File.WriteAllText("tipos.json", json);
                CargarPesonajesALista(Personajes, 8);
                PersonajesJson1.GuardarPersonaje(Personajes, "personajes.json");
                System.Console.WriteLine("2");   
            }
            
        }
      
        /*---------------------------------------------------------------------------------------------------*/
       
        System.Console.WriteLine("----------------BIENVENIDOS A LA PELEA DEL SIGLO----------------");
        int ronda = 1;

        while (Personajes.Count > 1)
        {
            ShowCurrentRound(ronda);
        

            List<Personaje> proximosPersonajes = new List<Personaje>();

            while (Personajes.Count > 1)
            {
                Personaje personaje1 = ElegirPersonaje(Personajes, random);
                Personaje personaje2 = ElegirPersonaje(Personajes, random);

                Console.WriteLine(personaje1.Nombre + " \""+personaje1.Apodo+"\" "+"de tipo: "+personaje1.Tipo +" vs "+ personaje2.Nombre + " \""+personaje2.Apodo+"\""+"de tipo: "+personaje2.Tipo);

                Personaje ganador = Lucha(personaje1, personaje2, random);

                proximosPersonajes.Add(ganador);
            }
                

            Personajes = proximosPersonajes;
            ronda++;
            if (ronda < 3)
            {
                System.Console.WriteLine("PRESIONE ENTER PARA SEGUIR");
                Console.ReadKey();
            }
            
        }        

        Console.WriteLine($"El ganador del torneo es: {Personajes[0].Nombre}");
        
    }

    private static void ShowCurrentRound(int ronda)
    {
        var TipoRonda = "";

        switch (ronda )
        {
            case 1:
            TipoRonda = "CUARTOS DE FINAL";
            break;

            case 2:
            TipoRonda = "SEMIFINALES";
            break;

            case 3:
            TipoRonda = "FINAL";
            break;
        }

        Console.WriteLine();
        Console.WriteLine($"--- Ronda {ronda} , {TipoRonda}  ---");
        Console.WriteLine();
    }

    public static List<string> GetClassesNames()
    {
            List<string> classesNames = new();  
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
                        if (strReader == null) return new List<string>();
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            var salida  = objReader.ReadToEnd();
                            var classes = JsonSerializer.Deserialize<PlayerTypeGroup>(salida)?.Classes;
                            classes?.ForEach(classes => classesNames.Add(classes.name));
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return new List<string>();
            }

            return classesNames;  
    }

    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(1); // Retardo de 100 milisegundos entre cada carácter
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
                AtacarPersonaje(p1,p2,random);
            }
            else
            {
                AtacarPersonaje(p2,p1,random);
            }

            i++;
        }

        if (p2.Salud <= 0)
        {
            System.Console.WriteLine(p1.Nombre + " ES EL GANADOR");
            System.Console.WriteLine();
            p1.Salud = 100;
            return p1;
        }
        else
        {
            System.Console.WriteLine(p2.Nombre + " ES EL GANADOR");
            System.Console.WriteLine();
            p2.Salud = 100;
            return p2;
        }
    }

    private static void AtacarPersonaje(Personaje atacante, Personaje defensor, Random random)
    {
        int i = 1;
        double ataque;
        double efectidad;
        double defensa;
        double DañoProvocado;
        int constanteDeAjuste = 100;

        ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel + 20;
        efectidad = random.Next(1, 101);
        defensa = defensor.Armadura * defensor.Velocidad;

        DañoProvocado = ((ataque * efectidad) - defensa) / constanteDeAjuste;
        defensor.Salud = defensor.Salud - DañoProvocado;

        // Calcular la longitud del mensaje más largo
        string mensajeAtaque = atacante.Nombre + " ATACA CON:" + poderes.poderesAtaque[random.Next(0, 10)];
        string mensajeDaño = "DAÑO REALIZADO: " + DañoProvocado.ToString("0.00");
        string mensajeVida = "La vida de " + defensor.Nombre + " es: " + defensor.Salud.ToString("0.00");
        int mensajeLongitud = Math.Max(mensajeAtaque.Length, Math.Max(mensajeDaño.Length, mensajeVida.Length));

        // Imprimir el recuadro alrededor de las 3 líneas
        Console.WriteLine(new string('-', mensajeLongitud + 4));
        EscribirMensaje($"| {mensajeAtaque.PadRight(mensajeLongitud)} |");
        EscribirMensaje($"| {mensajeDaño.PadRight(mensajeLongitud)} |");
        EscribirMensaje($"| {mensajeVida.PadRight(mensajeLongitud)} |");
        Console.WriteLine(new string('-', mensajeLongitud + 4));


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


