using Domain.Enums;

namespace QuipuWeb.Dto
{

    public record AddressCreateUpdateRequestDTO(string name, string postCode, Guid? IdClient, string type);
    public record AddressCreateUpdateResponsDTO(Guid? id, string? name, string? postCode, Guid? IdClient, AddressTypeEnum? type);
    public record AddressDTO(Guid? id, string? name, string? postCode, Guid? IdClient, AddressTypeEnum? type);

}
