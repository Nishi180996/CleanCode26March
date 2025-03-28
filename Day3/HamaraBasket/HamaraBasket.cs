
using System.Collections.Generic;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        private readonly IList<Item> Items;

        public HamaraBasket(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Quality >= 50)
                {
                    Items[i].Quality = 50;
                    break;
                }
                if (Items[i].Quality <= 0)
                {
                    Items[i].Quality = 0;
                    break;
                }

                switch (Items[i].Name)
                {

                    case "Indian Wine":
                        if (Items[i].Quality < 50 && Items[i].SellIn >= 0)
                        {
                            Items[i].Quality += 1;
                        }

                        break;

                    case "Movie Tickets":
                        if (Items[i].Quality < 50 && Items[i].SellIn >= 0)
                        {
                            Items[i].Quality += 1;

                            if (Items[i].SellIn < 11 && Items[i].Quality < 50)
                            {
                                Items[i].Quality += 1;
                            }

                            if (Items[i].SellIn < 6 && Items[i].Quality < 50)
                            {
                                Items[i].Quality += 1;
                            }
                        }

                        break;

                    case "Forest Honey":
                        // Forest Honey quality does not change
                        break;

                    default:
                        if (Items[i].Quality > 0)
                        {
                            Items[i].Quality -= 1;
                        }

                        break;
                }

                if (Items[i].Name != "Forest Honey")
                {
                    Items[i].SellIn -= 1;
                }

                if (Items[i].SellIn < 0)
                {
                    switch (Items[i].Name)
                    {
                        case "Indian Wine":
                            // Indian Wine quality does not change once its expires
                            break;

                        case "Forest Honey":
                            // Forest Honey quality does not change
                            break;

                        case "Movie Tickets":
                            Items[i].Quality = 0;
                            break;

                        default:
                            if (Items[i].Quality > 0)
                            {
                                Items[i].Quality -= 1;
                            }

                            break;


                    }
                }
            }
        }
    }
}


//namespace hamaraBasket
//{
//    public class HamaraBasket
//    {
//        IList<Item> Items;
//        public HamaraBasket(IList<Item> Items)
//        {
//            this.Items = Items;
//        }

//        public void UpdateQuality()
//        {
//            for (var i = 0; i < Items.Count; i++)
//            {
//                if (Items[i].Name != "Indian Wine" && Items[i].Name != "Movie Tickets")
//                {
//                    if (Items[i].Quality > 0)
//                    {
//                        if (Items[i].Name != "Forest Honey")
//                        {
//                            Items[i].Quality = Items[i].Quality - 1;
//                        }
//                    }
//                }
//                else
//                {
//                    if (Items[i].Quality < 50)
//                    {
//                        Items[i].Quality = Items[i].Quality + 1;

//                        if (Items[i].Name == "Movie Tickets")
//                        {
//                            if (Items[i].SellIn < 11)
//                            {
//                                if (Items[i].Quality < 50)
//                                {
//                                    Items[i].Quality = Items[i].Quality + 1;
//                                }
//                            }

//                            if (Items[i].SellIn < 6)
//                            {
//                                if (Items[i].Quality < 50)
//                                {
//                                    Items[i].Quality = Items[i].Quality + 1;
//                                }
//                            }
//                        }
//                    }
//                }

//                if (Items[i].Name != "Forest Honey")
//                {
//                    Items[i].SellIn = Items[i].SellIn - 1;
//                }

//                if (Items[i].SellIn < 0)
//                {
//                    if (Items[i].Name != "Indian Wine")
//                    {
//                        if (Items[i].Name != "Movie Tickets")
//                        {
//                            if (Items[i].Quality > 0)
//                            {
//                                if (Items[i].Name != "Forest Honey")
//                                {
//                                    Items[i].Quality = Items[i].Quality - 1;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
//                        }
//                    }
//                    else
//                    {
//                        if (Items[i].Quality < 50)
//                        {
//                            Items[i].Quality = Items[i].Quality + 1;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}