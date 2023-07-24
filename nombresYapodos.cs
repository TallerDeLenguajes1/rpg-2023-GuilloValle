namespace CrearPersonaje
{
    public static class nombresYapodos
    {
        public static string[] nombres = {
            "Juan",
            "María",
            "Pedro",
            "Ana",
            "Luis",
            "Laura",
            "Carlos",
            "Sofía",
            "Diego",
            "Valentina"

            };

        public static string[] apodos = {
            "Lui",
            "Mar",
            "Pete",
            "Ani",
            "Jota",
            "Carli",
            "Sofi",
            "Dany",
            "Migue",
            "Luchi"
            };


    

    }

    public class Result
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }

}