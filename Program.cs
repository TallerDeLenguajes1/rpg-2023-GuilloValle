// See https://aka.ms/new-console-template for more information
using CrearPersonaje;
using System.Text.Json;


internal class Program
{
    private static void Main(string[] args)
    {

        var Personajes = new List<Personaje>();      //LISTA CON LOS PERSONAJES
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
            CargarPesonajesALista(Personajes, 10);
            PersonajesJson1.GuardarPersonaje(Personajes, "personajes.json");
            // foreach (var personaje in Personajes)
            // {
            //     MostrarDatos(personaje);
            // }
        }

        

    }

    private static void Lucha(Personaje p1,Personaje p2, Random random)
    {
        int i = 1;
        double ataque;
        double efectidad;
        double defensa;
        double DañoProvocado;
        int constanteDeAjuste = 500;


        while (p1.Salud > 0 && p2.Salud > 0)
        {
            if (i % 2 == 0)  //FORMA PARA QUE ATAQUE UNO A LA VEZ
            {
                ataque = p1.Destreza * p1.Fuerza * p1.Nivel;
                efectidad = random.Next(1, 101);
                defensa = p2.Armadura * p2.Velocidad;

                DañoProvocado = ((ataque * efectidad) - defensa) / constanteDeAjuste;
                p2.Salud = p2.Salud - DañoProvocado;
                System.Console.WriteLine(p1.Nombre + " utiliza el poder de:" + poderes.poderesAtaque[random.Next(0, 10)]);

            }
            else
            {
                ataque = p2.Destreza * p2.Fuerza * p2.Nivel;
                efectidad = random.Next(1, 101);
                defensa = p1.Armadura * p1.Velocidad;

                DañoProvocado = ((ataque * efectidad) - defensa) / constanteDeAjuste;
                p1.Salud = p1.Salud - DañoProvocado;
                System.Console.WriteLine(p2.Nombre + " utiliza el poder de:" + poderes.poderesAtaque[random.Next(0, 10)]);
            }

            i++;
        }

        if (p2.Salud <= 0)
        {
            System.Console.WriteLine(p1.Nombre + " ES EL GANADOR");
        }
        else
        {
            System.Console.WriteLine(p2.Nombre + " ES EL GANADOR");
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


