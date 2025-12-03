namespace Populator
{
  public static class XdomeaPopulator
  {
    public static string Populate(Dictionary<string, string> vars, string template)
    {
      foreach (var item in vars)
      {
        var searchString = "${" + item.Key + "}";
        template = template.Replace(searchString, item.Value);
      }
      return template;
    }


    public static string PopulateList(
    IEnumerable<Dictionary<string, string>> vars,
    string listTemplate)
    {
      var res = "";
      foreach (var dict in vars)
      {
        res += Populate(dict, listTemplate);
      }
      return res;
    }
  }
}
