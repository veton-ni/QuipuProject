
namespace QuipuWeb.Dto
{

    public record ClientCreateUpdateRequestDTO(string name, string email, string? phone, DateTime? birthdate);
    public record ClientCreateUpdateResponsDTO(Guid id, string name, string email, string? phone, DateTime? birthdate);
    public record ClientDTO(Guid id, string name, string email, string? phone, DateTime? birthdate, List<AddressDTO> address);

}
