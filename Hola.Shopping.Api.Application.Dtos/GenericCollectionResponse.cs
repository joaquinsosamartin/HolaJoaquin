namespace Hola.Shopping.Api.Application.Dtos
{
    public class GenericCollectionResponse<T> where T : class
    {
        public T Result { get; set; }
        public int TotalRecords { get; set; }
    }
}
