﻿using System;
using System.ComponentModel;

public static class StringExtensions
{
  // Methods
  public static TValue As<TValue>(this string value)
  {
    return value.As<TValue>(default(TValue));
  }

  public static TValue As<TValue>(this string value, TValue defaultValue)
  {
    try
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
      if (converter.CanConvertFrom(typeof(string)))
      {
        return (TValue)converter.ConvertFrom(value);
      }
      converter = TypeDescriptor.GetConverter(typeof(string));
      if (converter.CanConvertTo(typeof(TValue)))
      {
        return (TValue)converter.ConvertTo(value, typeof(TValue));
      }
    }
    catch (Exception)
    {
    }
    return defaultValue;
  }

  public static bool AsBool(this string value)
  {
    return value.As<bool>(false);
  }

  public static bool AsBool(this string value, bool defaultValue)
  {
    return value.As<bool>(defaultValue);
  }

  public static DateTime AsDateTime(this string value)
  {
    return value.As<DateTime>();
  }

  public static DateTime AsDateTime(this string value, DateTime defaultValue)
  {
    return value.As<DateTime>(defaultValue);
  }

  public static decimal AsDecimal(this string value)
  {
    return value.As<decimal>();
  }

  public static decimal AsDecimal(this string value, decimal defaultValue)
  {
    return value.As<decimal>(defaultValue);
  }

  public static float AsFloat(this string value)
  {
    return value.As<float>();
  }

  public static float AsFloat(this string value, float defaultValue)
  {
    return value.As<float>(defaultValue);
  }

  public static int AsInt(this string value)
  {
    return value.As<int>();
  }

  public static int AsInt(this string value, int defaultValue)
  {
    return value.As<int>(defaultValue);
  }

  public static bool Is<TValue>(this string value)
  {
    TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
    return (((converter != null) && converter.CanConvertFrom(typeof(string))) && converter.IsValid(value));
  }

  public static bool IsBool(this string value)
  {
    return value.Is<bool>();
  }

  public static bool IsDateTime(this string value)
  {
    return value.Is<DateTime>();
  }

  public static bool IsDecimal(this string value)
  {
    return value.Is<decimal>();
  }

  public static bool IsEmpty(this string value)
  {
    return string.IsNullOrEmpty(value);
  }

  public static bool IsFloat(this string value)
  {
    return value.Is<float>();
  }

  public static bool IsInt(this string value)
  {
    return value.Is<int>();
  }
}