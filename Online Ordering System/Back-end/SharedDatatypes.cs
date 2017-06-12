﻿using System;

public enum DeliveryState { Pending, InProgress, Delieverd };

public struct ItemDisc : IComparable
{
    public DeliveryState state;
    public static int ComparisonCo = 0;
    public int ID;
    public string name;
    public float price;
    public int Quantity;
    public string Type;
    public string manfacture;
    public int CompareTo(object o)
    {
        if (o.GetType() == GetType())
        {
            switch (ComparisonCo)
            {
                case 0:
                    return ID.CompareTo(((ItemDisc)o).ID);
                case 1:
                    return name.CompareTo(((ItemDisc)o).name);
                default:
                    return price.CompareTo(((ItemDisc)o).price);
            }
        }
        else return 0;
    }
};

public struct User
{
    public static User ActiveUser;
    public static bool IsLoggedIn = false;
    public int ID;
    public string Username, Password , address;
    public Marketing process;
}