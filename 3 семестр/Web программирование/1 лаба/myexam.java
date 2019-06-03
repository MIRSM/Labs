import java.util.Scanner;
class myexam
{
	public static void main (String args[])

		{
			Scanner in=new Scanner(System.in);
			System.out.println("Введите n:");
			int n=in.nextInt();
			int m =0;
			int[] arr = new int[n];
			System.out.println("Введите "+n+" целых чисел:");
			for(int i=0;i<n;i++){
				arr[i]=in.nextInt();
				if(arr[i]>m) m=arr[i];
			}
			System.out.println("Числа, входящие в ряд Фиббоначи:");
			int last=1, last1=1;
			for(int i=0; i<m; i++){
				int a=last;
				last+=last1;
				last1=a;
				for(int j=0;j<n;j++){
					if (arr[j]==last1) System.out.print(arr[j]+" ");
				}
			}
		}
}