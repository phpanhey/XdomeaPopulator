namespace Populator{
    public static class XdomeaPopulator
    {
      public static string Populate(KeyValuePair<string, string>[] vars, string template){
        foreach (var item in vars)
        {
          var searchString = "${" + item.Key +"}";
         template = template.Replace(searchString,item.Value);
        }
        return template;
      }
    }
}
