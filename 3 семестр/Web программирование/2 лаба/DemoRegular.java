import java.util.regex.*;
import java.util.Scanner;

public class DemoRegular {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String regex = "(\\w+)@(\\w+).[a-z]{2,}+$|(\\w+)@(\\w+)+$";
		String s=" ";
		String regex1="^+[q]+$";
		Pattern p1=Pattern.compile(regex1);
		while (!p1.matcher(s).find()) {
			System.out.println("Введите e-mail:");
			s = in.nextLine();
			Pattern p2 = Pattern.compile(regex);
			Matcher m2 = p2.matcher(s);
			if (m2.find())
				System.out.println("e-mail: " + m2.group());
			else
				System.out.println("Неверный e-mail!");
			System.out.println("Если хотите выйти, введите y:");
			if((in.nextLine()+" ").charAt(0)=='y')
				s="q";
		}
	}
}
