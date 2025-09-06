﻿namespace EticaretCanta.ViewModel
{
    public class PageResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages=>(int)Math.Ceiling((double)TotalItems/PageSize);
    }
}
