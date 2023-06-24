// See https://aka.ms/new-console-template for more information
using CrearPersonaje;
using System.Text.Json;


internal class Program
{
    private static void Main(string[] args)
    {

        var Personajes = new List<Personaje>();      //LISTA CON LOS PERSONAJES
        var PersonajesJson1 = new PersonajesJson();  // INSTACIO LA CLASE PARA PODER USAR LOS METODOS
        Random random = new Random();


        if (PersonajesJson1.Existe("personajes.json"))
        {   
            
            Personajes = PersonajesJson1.LeerPesonajes("personajes.json");
            // foreach (var personaje in Personajes)
            // {
            //     MostrarDatos(personaje);
            // }
            
            
        }else
        {
            CargarPesonajesALista(Personajes,10);
            PersonajesJson1.GuardarPersonaje(Personajes,"personajes.json");
            // foreach (var personaje in Personajes)
            // {
            //     MostrarDatos(personaje);
            // }
        }

        int i = 1;
        while (Personajes[2].Salud > 0 && Personajes[7].Salud > 0)
        {
            if (i%2 == 0)  //FORMA PARA QUE ATAQUE UNO A LA VEZ
            {
                double ataque = Personajes[2].Destreza * Personajes[2].Fuerza * Personajes[2].Nivel;
                double efectidad = random.Next(1, 101);
                double defensa = Personajes[7].Armadura * Personajes[7].Velocidad;
                int constanteDeAjuste = 500;
                double DañoProvocado = ((ataque*efectidad) - defensa)/constanteDeAjuste;
                Personajes[7].Salud = Personajes[7].Salud - DañoProvocado;
                System.Console.WriteLine(Personajes[2].Nombre + " utiliza el poder de:" + poderes.poderesAtaque[random.Next(0, 10)]);

            }else
            {
                double ataque = Personajes[7].Destreza * Personajes[7].Fuerza * Personajes[7].Nivel;
                double efectidad = random.Next(1, 101);
                double defensa = Personajes[2].Armadura * Personajes[2].Velocidad;
                int constanteDeAjuste = 500;
                double DañoProvocado = ((ataque*efectidad) - defensa)/constanteDeAjuste;
                Personajes[2].Salud = Personajes[2].Salud - DañoProvocado;
                System.Console.WriteLine(Personajes[7].Nombre + " utiliza el poder de:" + poderes.poderesAtaque[random.Next(0, 10)]);            
            }

            i++;
        }

        if (Personajes[2].Salud <= 0)
        {
            System.Console.WriteLine(Personajes[2].Nombre + " ES EL GANADOR");
        }else
        {
            System.Console.WriteLine(Personajes[7].Nombre + " ES EL GANADOR");
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


