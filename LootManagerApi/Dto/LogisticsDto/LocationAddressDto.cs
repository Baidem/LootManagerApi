using System.Reflection;
using System.Text;


namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationAddressDto
    {
        #region PROPERTIES

        public int? Location_Id { get; set; }

        public int? House_Id { get; set; }
        public string? House_Name { get; set; }
        public int? House_Indice { get; set; }

        public int? Room_Id { get; set; }
        public string? Room_Name { get; set; }
        public int? Room_Indice { get; set; }

        public int? Furniture_Id { get; set; }
        public string? Furniture_Name { get; set; }
        public int? Furniture_Indice { get; set; }

        public int? Shelf_Id { get; set; }
        public string? Shelf_Name { get; set; }
        public int? Shelf_Indice { get; set; }

        public int? Position_Id { get; set; }
        public string? Position_Name { get; set; }
        public int? Position_Indice { get; set; }

        #endregion

        #region CONSTRUCTORS

        public LocationAddressDto()
        {
        }


        // TODO Obosolete
        //public LocationAddressDto(Location location)
        //{
        //    Location_Id = location.Id;

        //    House_Id = location.House.Id;
        //    House_Name = location.House.Name;
        //    House_Indice = location.House.Indice;

        //    if (location.Room == null)
        //    {
        //        Room_Id = null;
        //        Room_Name = null;
        //        Room_Indice = null;
        //    }
        //    else
        //    {
        //        Room_Id = location.Room.Id;
        //        Room_Name = location.Room.Name;
        //        Room_Indice = location.Room.Indice;
        //    }


        //    if (location.Furniture == null)
        //    {
        //        Furniture_Id = null;
        //        Furniture_Name = null;
        //        Furniture_Indice = null;
        //    }
        //    else
        //    {
        //        Furniture_Id = location.Furniture.Id;
        //        Furniture_Name = location.Furniture.Name;
        //        Furniture_Indice = location.Furniture.Indice;
        //    }


        //    if (location.Shelf == null)
        //    {
        //        Shelf_Id = null;
        //        Shelf_Name = null;
        //        Shelf_Indice = null;
        //    }
        //    else
        //    {
        //        Shelf_Id = location.Shelf.Id;
        //        Shelf_Name = location.Shelf.Name;
        //        Shelf_Indice = location.Shelf.Indice;
        //    }


        //    if (location.Position == null)
        //    {
        //        Position_Id = null;
        //        Position_Name = null;
        //        Position_Indice = null;
        //    }
        //    else
        //    {
        //        Position_Id = location.Position.Id;
        //        Position_Name = location.Position.Name;
        //        Position_Indice = location.Position.Indice;
        //    }
        //}

        #endregion

        #region METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        #endregion

    }
}
