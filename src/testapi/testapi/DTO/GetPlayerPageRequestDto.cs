using System.ComponentModel;

namespace testapi.DTO
{
    public class GetPlayerPageRequestDto
    {
        [DefaultValue(0)]
        public int Page { get; set; }
    }
}
