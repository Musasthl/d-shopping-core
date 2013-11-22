using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTier.Entities;
using Service.DTO;

namespace Service
{
    public class ConverterProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            #region Category

            Mapper.CreateMap<Categories, CategoryDto>();

            #endregion
            #region Product

            Mapper.CreateMap<Products, ProductDto>()
                .ForMemberEx(d => d.CategoryId, s => s.GetCategoryId())
                .ForMember(d => d.Category, s => s.Ignore())
                .ForMember(d => d.ProductDetails, s => s.Ignore());

            Mapper.CreateMap<Products, ProductOverviewDto>()
                .ForMemberEx(d => d.Image, 
                            s => s.ProductDetails.
                                    FirstOrDefault(p => p.ProductTypeId.Id == CONST.STATUS.P_IMAGE 
                                                        && p.Status.Id == "Active"
                                                  )
                            )
                            .ForMemberEx(d => d.Price, s => s.Price ?? 0);

            #endregion

            
        }
    }
    #region Extensions
    internal static class IMappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDestination> ForMemberEx<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, object>> destinationMember,
            Func<TSource, object> sourceMember)
        {
            return mappingExpression.ForMember(destinationMember, cfg => cfg.MapFrom(s => sourceMember));
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, object>> destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, cfg => cfg.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> Bidirectional<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            Mapper.CreateMap<TDestination, TSource>();

            return mappingExpression;
        }
    }
    #endregion
}
