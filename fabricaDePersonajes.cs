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
            nuevoPersonaje.Nombre = nombresYapodos.nombres[random.Next(0, 30)];
            nuevoPersonaje.Apodo = nombresYapodos.apodos[random.Next(0, 30)];
            if (File.Exists("tipos.json"))
            {   
                var jsonString = File.ReadAllText("tipos.json");
                var classesNames = JsonSerializer.Deserialize<List<string>>(jsonString);
                if (classesNames.Count > 0)
                {
                    int rand = random.Next(0, classesNames.Count);
                    nuevoPersonaje.Tipo = classesNames[rand];
                    classesNames.RemoveAt(rand);

                    // Guardar el JSON actualizado sin el elemento seleccionado
                    jsonString = JsonSerializer.Serialize(classesNames);
                    File.WriteAllText("tipos.json", jsonString);
                }
               
            }else
            {
                nuevoPersonaje.Tipo = nombresYapodos.tiposDePersonajes[random.Next(0, 30)];
            }
           
            nuevoPersonaje.Edad = random.Next(10,100);
            int añoactual=DateTime.Now.Year;
            int añonacimiento=añoactual-nuevoPersonaje.Edad;
            nuevoPersonaje.FechaDenacimiento = new DateTime(añonacimiento,random.Next(1,13),random.Next(1,30));
            return nuevoPersonaje;

        }
    }
}