//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Screening
    {
        public int BookID { get; set; }
        public string Film_Name { get; set; }
        public System.DateTime Year { get; set; }
        public string Link { get; set; }
    
        public virtual Book Book { get; set; }
    }
}
