# Paginator
Simple paginator for Linq (EF)

## Installation

You can install by [NuGet Manager](https://www.nuget.org/packages/Paginator/) or by NuGet Console by the command `PM> Install-Package Paginator`.

## Using

You can paginate a `IQueryable` object. For example:

```csharp
using (var db = new MyDearDatabase())
{
  var page = db.Users.Page(user => user.Name);
  page.Index //Current index
  page.Length //Current page length
  page.Count //Total of users
  page.Itens //Array of users
}
```

By default, the `Index` of you page will 1 and the `Length`of page 10.
You can set defaults in the class `Paginator.Defaults` or you can pass to `Page()` a index e length.

```csharp
using (var db = new MyDearDatabase(int index, int pageLength))
{
 //You can do it, but you will change the Defaults for all Page method
  Paginator.Defaults.Index = index;
  Paginator.Defaults.Length = pageLength;
  var page1 = db.Users.Page(user => user.Name);
  
  //Or this
  var page2 = db.Users.Page(user => user.Name, index, pageLength);
}
```

The class `PageRequest` is to help to pass the pagination, in case you want it.
In that class you will set `Index` and `Length`.

```csharp
public void AwesomeMethod(PageRequest pageRequest)
{
  using (var db = new MyDearDatabase())
  {
    var page = db.Users.Page(user => user.Name, pageRequest);
  }
}
```
