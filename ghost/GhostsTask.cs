using System;
using System.Text;

namespace hashes
{
	public class GhostsTask : 
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		IMagic
	{             
        Cat cat = new Cat("Вася", "жопа", DateTime.Now);
        static byte[] content = Encoding.ASCII.GetBytes("Жопа");
        Document document = new Document("1.txt", Encoding.ASCII, content);
        Vector vector = new Vector(4, 3);
        Segment segment = new Segment(new Vector(3, 5), new Vector(5, 6));
        Robot robot = new Robot("123");

        public void DoMagic()
		{           
            for (int i = 0; i < content.Length; i++)
            {
                content[i]++;
            }
            cat.Rename("Бетмен");
            vector.Add(new Vector(6, 8));
            segment.End.Add(new Vector(7, 9));
            Robot.BatteryCapacity -= 20; 
		}

        // Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
        // придется воспользоваться так называемой явной реализацией интерфейса.
        // Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
        // На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

        Document IFactory<Document>.Create() => document;

        Vector IFactory<Vector>.Create() => vector;
		
		
        Segment IFactory<Segment>.Create() => segment;
        
        Cat IFactory<Cat>.Create() => cat;

        Robot IFactory<Robot>.Create() => robot;
       
    }
}