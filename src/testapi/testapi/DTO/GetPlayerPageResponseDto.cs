namespace testapi.DTO
{
    public class GetPlayerPageResponseDto
    {
        public PlayerDto[] Players { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPlayers { get; set; }
    }
}
