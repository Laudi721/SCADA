﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Dynamic;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Base.StaticMethod
{
    public static class Mapper
    {
        public static List<T> MapCollection<T>(object source, int mappingLevel = 2) where T : class
        {
            return MapCollection(source, typeof(List<T>), mappingLevel) as List<T>;
        }

        public static object MapCollection(object source, Type resultType, int mappingLevel = 2)
        {
            var result = Activator.CreateInstance(resultType) as IList;

            var singleElementType = resultType.GenericTypeArguments[0];            

            foreach (var item in (source as IEnumerable))
            {
                if((bool)item.GetType().GetProperty("IsDeleted").GetValue(item))
                    continue;

                result.Add(Map(item, singleElementType, mappingLevel));
            }

            return result;
        }

        public static T Map<T>(object source, int mappingLevel = 2) where T : class
        {
            return Map(source, typeof(T), mappingLevel) as T;
        }

        private static object Map(object source, Type result, int mappingLevel = 2)
        {
            if (source == null)
                return null;

            var sourceType = source.GetType();

            var resultProperties = GetTypeProperties(result);
            var sourceProperties = GetTypeProperties(sourceType);

            var resultObject = Activator.CreateInstance(result) as object;

            foreach (var property in resultProperties)
            {
                var setter = SetterProperty(result, property.Name);
                
                if (setter == null)
                    continue;

                if (!sourceProperties.Any(a => a.Name.Equals(property.Name)))
                    continue;

                var getter = GetterProperty(sourceType, property.Name);

                if (getter == null)
                    continue;

                var propertyType = property.PropertyType;

                if (propertyType.IsSealed)
                    HandleSimpleMapping(getter, setter, source, resultObject, propertyType);
                else if (!propertyType.IsSealed && mappingLevel > 0)
                    HandleModelMapping(getter, setter, source, resultObject, propertyType, mappingLevel - 1);
            }

            return resultObject;
        }

        private static void HandleSimpleMapping(PropertyInfo getter, PropertyInfo setter, object source, object destination, Type propertyType)
        {
            if (getter.PropertyType == propertyType && setter.CanWrite)
            {
                var value = getter.GetValue(source);
                setter.SetValue(destination, value);
            }
        }

        private static void HandleModelMapping(PropertyInfo getter, PropertyInfo setter, object source, object destination, Type propertyType, int mappingLevel)
        {
            var sourceValue = getter.GetValue(source);

            if (sourceValue == null)
            {
                setter.SetValue(destination, null);
                return;
            }

            if (!(sourceValue is IEnumerable))
            {
                var resultValue = Activator.CreateInstance(propertyType).GetType();
                var obj = Map(sourceValue, resultValue, mappingLevel - 1);
                setter.SetValue(destination, obj);

            }
            else if(sourceValue is IEnumerable)
            {
                var propType = propertyType.GenericTypeArguments.First();
                var collection = Activator.CreateInstance(propertyType) as IList;

                if (!propType.IsSealed)
                {
                    foreach (var item in (sourceValue as IEnumerable))
                    {
                        var genericInstance = Map(item, propType, mappingLevel);

                        collection.Add(genericInstance);
                    }
                }
                //var resultValue = Activator.CreateInstance(propertyType).GetType();
                //var obj = Map(sourceValue, resultValue, mappingLevel - 1);

                setter.SetValue(destination, collection);
            }
            //setter.SetValue(destination, obj);
        }

        private static PropertyInfo SetterProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName);
        }

        private static PropertyInfo GetterProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName);
        }

        public static List<PropertyInfo> GetTypeProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
        }

        //public static T Map<T>(object item, object model)
        //{
        //    var result = Activator.CreateInstance<T>();

        //    var ss = item.GetType().GetProperties().ToList();

        //    foreach (var property in item.GetType().GetProperties())
        //    {
        //        var sourceValue = property.GetValue(item);
        //        var targetValue = model.GetType().GetProperty(property.Name);

        //        var sourceValueType = property.PropertyType;
        //        if (sourceValueType.IsValueType || sourceValueType == typeof(string))
        //        {
        //            var sourceValue2 = item.GetType().GetProperty(property.Name);
        //            targetValue.SetValue(result, sourceValue);
        //        }
        //        else if (sourceValueType.IsGenericType)
        //        {
        //            var innerItem = property.PropertyType.GetGenericArguments()[0];
        //            var innerModel = targetValue.PropertyType.GetGenericArguments()[0];

        //            var listValues = new List<object>();
        //            foreach (var single in sourceValue as IList)
        //            {
        //                listValues.Add(SingleMapping(single, innerModel));
        //            }

        //            targetValue.SetValue(result, listValues);
        //        }
        //        else if (sourceValueType.IsClass)
        //        {
        //            var innerItem = property.PropertyType;
        //            var innerModel = targetValue.PropertyType;

        //            var value = SingleMapping(innerItem, innerModel);
        //        }
        //    }

        //    return result;
        //}
    }
}
