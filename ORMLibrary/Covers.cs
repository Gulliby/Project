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
    
    public partial class Covers
    {
        public int CoverID { get; set; }
        public int BookID { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Books Books { get; set; }
    }
}