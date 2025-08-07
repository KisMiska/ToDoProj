using System;

namespace Application.DTOs
{
    public class UpdateResponseDTO
    {
        public bool IsUpdateSuccessful { get; set; }

        public UpdateResponseDTO(bool isUpdateSuccessful)
        {
            IsUpdateSuccessful = isUpdateSuccessful;
        }
    }
}
