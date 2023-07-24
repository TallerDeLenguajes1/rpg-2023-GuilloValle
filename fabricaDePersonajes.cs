using System.Text.Json;
namespace CrearPersonaje
{

    public class fabricaDePersonajes 
    {
        public Personaje crearPersonaje()
        {
            var nuevoPersonaje = new Personaje();
            Random random = new Random();

            // Asignar valores aleatorios a las propiedades del personaje
            nuevoPersonaje.Velocidad = random.Next(1, 11);
            nuevoPersonaje.Destreza = random.Next(1, 6);
            nuevoPersonaje.Fuerza = random.Next(1, 11);
            nuevoPersonaje.Nivel = random.Next(1, 11);
            nuevoPersonaje.Armadura = random.Next(1, 11);
            nuevoPersonaje.Salud = 100;
            var valoresTipo = Enum.GetValues(typeof(tipo));
            nuevoPersonaje.Tipo = (tipo)valoresTipo.GetValue(random.Next(valoresTipo.Length));
            nuevoPersonaje.Nombre = nombresYapodos.nombres[random.Next(0, 10)];
            var jsonString = File.ReadAllText("tipos.json");
            Root personajesDeserializados = JsonSerializer.Deserialize<Root>(jsonString);
            int rand = random.Next(0, personajesDeserializados.results.Count());
            nuevoPersonaje.Apodo = personajesDeserializados.results[rand].name;
            personajesDeserializados.results.RemoveAt(rand);
            nuevoPersonaje.Edad = random.Next(10,100);
            int añoactual=DateTime.Now.Year;
            int añonacimiento=añoactual-nuevoPersonaje.Edad;
            nuevoPersonaje.FechaDenacimiento = new DateTime(añonacimiento,random.Next(1,13),random.Next(1,30));
            return nuevoPersonaje;

        }
    }
}