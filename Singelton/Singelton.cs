// This projectCreated with .net 6.0
// این پرژه با دات نت 6 ساخته شده است

namespace Singelton;

// Singleton design pattern in C# is one of the most popular design patterns. In this pattern, a class has only one instance in the program that provides a global point of access to it. In other words, a singleton is a class that allows only a single instance of itself to be created and usually gives simple access to that instance.
// الگوی طراحی سینگلتون در سی شارپ یکی از محبوب ترین الگوهای طراحی است. در این الگو، یک کلاس تنها یک نمونه در برنامه دارد که یک نقطه دسترسی سراسری به آن فراهم می کند. به عبارت دیگر، سنگلتون کلاسی است که اجازه می دهد تنها یک نمونه از خودش ایجاد شود و معمولاً به آن نمونه دسترسی ساده می دهد.

public sealed class ChatGPT
{
    private ChatGPT() { }
    private static ChatGPT instance = null;

    // تنها نمونه ای که میتوان از کلاس در تمام پروژه داشت همین است. بیشتر زمانی کاربرد دارد که شئ گرایی هم نیاز و هم پاشنه آشیل کار هست
    public static ChatGPT Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChatGPT();
            }
            return instance;
        }
    }
}