﻿namespace CatFactory.Markup
{
    /// <summary>
    /// 
    /// </summary>
    public static class Html
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag A(object content, object attribs = null)
            => new Tag { Name = "a", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag B(object content, object attribs = null)
            => new Tag { Name = "b", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Tag Br()
            => new Tag { Name = "br", IsSelfClosed = true };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag Div(object content, object attribs = null)
            => new Tag { Name = "div", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Tag Hr()
            => new Tag { Name = "hr", IsSelfClosed = true };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag I(object content, object attribs = null)
            => new Tag { Name = "i", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag P(object content, object attribs = null)
            => new Tag { Name = "p", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H1(object content, object attribs = null)
            => new Tag { Name = "h1", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H2(object content, object attribs = null)
            => new Tag { Name = "h2", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H3(object content, object attribs = null)
            => new Tag { Name = "h3", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H4(object content, object attribs = null)
            => new Tag { Name = "h4", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H5(object content, object attribs = null)
            => new Tag { Name = "h5", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag H6(object content, object attribs = null)
            => new Tag { Name = "h5", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static ListTag Ol(object attribs = null)
            => new ListTag { Name = "ol", Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Tag Script(string src)
            => new Tag { Name = "script", Attributes = new { src }.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag Span(object content, object attribs = null)
            => new Tag { Name = "span", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static TableTag Table(object attribs = null)
            => new TableTag { Name = "table", Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static Tag Strong(object content, object attribs = null)
            => new Tag { Name = "strong", Content = content.ToString(), Attributes = attribs.GetAttributes() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribs"></param>
        /// <returns></returns>
        public static ListTag Ul(object attribs = null)
            => new ListTag { Name = "ul", Attributes = attribs.GetAttributes() };
    }
}
