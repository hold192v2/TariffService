

namespace TariffService.Domain.Entities
{
    public class UnitPrice : BaseEntity
    {
        public Guid Id { get; set; }
        public decimal MinutePrice { get; set; }
        public decimal GigabytePrice { get; set; }
        public decimal SmsPrice { get; set; }
        public bool UnlimVideoPrice { get; set; }
        public bool UnlimSocialsPrice { get; set; }
        public bool UnlimMusicPrice { get; set; }
        public bool LongDistanceCallPrice { get; set; }

    }
}