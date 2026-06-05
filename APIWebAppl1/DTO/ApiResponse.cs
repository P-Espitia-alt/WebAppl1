namespace APIWebAppl1.DTO
{
    public class ApiResponse<T>
    {
        // El modelo o lista de datos que quieres devolver
        public T? Data { get; set; }

        // Mensaje descriptivo para el cliente o frontend
        public string Message { get; set; } = string.Empty;

        // Código de estado HTTP (200, 400, 404, 500, etc.)
        public int StatusCode { get; set; }

        // Propiedad calculada muy útil para que el Frontend sepa rápido si todo salió bien
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;

        // Constructor vacío por defecto (necesario para la serialización JSON)
        public ApiResponse() { }

        // Constructor rápido para respuestas EXITOSAS
        public ApiResponse(T data, string message = "Operación exitosa", int statusCode = 200)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        // Constructor rápido para respuestas de ERROR (sin datos)
        public ApiResponse(string message, int statusCode = 400)
        {
            Data = default; // Será null para objetos de referencia
            Message = message;
            StatusCode = statusCode;
        }
    }
}
