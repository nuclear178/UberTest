using System.Collections.Generic;
using System.Linq;

namespace Application.Dtos.Assemblers
{
    public abstract class DtoAssembler<TEntity, TDto>
    {
        public abstract TDto ConvertToDto(TEntity entity);

        public IEnumerable<TDto> ConvertToDto(IEnumerable<TEntity> entities)
        {
            return entities.Select(ConvertToDto);
        }
    }
}