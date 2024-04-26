
namespace Recrovit.RecroGridFramework.Core;

public partial class RgfCore<TEntity> : RecroGridDBC<TEntity> where TEntity : class
{
    public RgfCore(IRecroGridContext rgContext) : base(rgContext) { }
}