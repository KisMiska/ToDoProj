
namespace Model.DTOs
{
    public class DeleteResponseDTO
    {
        public bool IsDeleteSuccesful;

        public DeleteResponseDTO(bool isDeleteSuccesful)
        {
            IsDeleteSuccesful = isDeleteSuccesful;
        }
    }
}
