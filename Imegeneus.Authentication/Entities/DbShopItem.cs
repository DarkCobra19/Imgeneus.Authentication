using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imgeneus.Authentication.Entities
{
    [Table("ShopItems")]
    public class DbShopItem
    {
        [Key]
        public uint Id { get; set; }

        public string? Icon { get; set; }

        public ushort Price { get; set; }

        public ShopItemCategory Category { get; set; }

        public ushort Type { get; set; }

        public byte TypeId { get; set; }
    }
}
