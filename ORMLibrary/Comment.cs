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
    
    public partial class Comment
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string Text { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
