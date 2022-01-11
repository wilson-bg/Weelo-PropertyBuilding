using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.Exceptions;

namespace Weelo.API.Filters
{
    public abstract class BaseFilterModel
    {

        public int PageIndex { get; set; }


        public int PageSize { get; set; } 


        protected int MaxPageSize { get; set; }



        private IList<ApiError> errors;
        public IList<ApiError> Errors
        {
            get
            {
                return this.errors ?? (errors = new List<ApiError>());
            }
        }

        protected void AddError(ExceptionCodes code, string message, string target = null)
        {
            this.AddError(code.ToString(), message, target);
        }

        protected void AddError(string code, string message, string target = null)
        {
            this.Errors.Add(new ApiError()
            {
                Code = ExceptionCodes.BadArgument.ToString(),
                Target = target,
                Message = message
            });
        }

        public virtual bool IsValid()
        {
            this.GeneralValidations();
            return this.errors == null || this.errors.Count == 0;
        }


        protected void GeneralValidations()
        {
            if (this.PageSize > this.MaxPageSize)
            {
                this.AddError(ExceptionCodes.BadArgument.ToString(), $"Tamaño máximo de paginación excedido. El máximo es {this.MaxPageSize}", "PageSize");
            }

            if (this.PageIndex < 0)
            {
                this.AddError(ExceptionCodes.BadArgument.ToString(), "La pagina debe ser mayor a 0", "Page");
            }

        }

    }
}
