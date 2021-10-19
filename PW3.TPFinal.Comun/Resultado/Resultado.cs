namespace PW3.TPFinal.Comun.Resultado
{
    public class Resultado
    {
        public bool Success { get; set; }

        public string Mensaje { get; set; }
    }

    public class Resultado<T> : Resultado
    {
        public T Dato { get; set; }
    }
}
