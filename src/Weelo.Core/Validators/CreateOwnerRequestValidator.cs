//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Weelo.Core.DTOs;

//namespace Weelo.Core.Validators
//{
//    public class CreateOwnerRequestValidator : AbstractValidator<CreateOwnerRequest>
//    {
//        public CreateOwnerRequestValidator()
//        {
//            RuleFor(p => p.Name)
//                .NotNull()
//                .WithMessage("El nombre no puede ser nulo");

//            RuleFor(p => p.Address)
//                .MaximumLength(100)
//                .WithMessage("La longitud del la dirección debe ser menor a 100 caracteres");

//            RuleFor(p => p.Birthday)
//                .NotNull()
//                .LessThan(DateTime.Now);
//        }

//    }
//}
