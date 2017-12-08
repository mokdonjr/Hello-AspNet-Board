# Hello-AspNet-Board
C#언어와 ASP.NET로 게시판 (Visual Studio 2012 / ASP.NET MVC 4 / LocalDB)



### Java / C# 프로그래밍 차이 정리

- package 대신 <pre><code>namespace 이름 { ... }</code></pre>를, 
  import 대신 <pre><code>using 이름;</code></pre> 키워드를 사용한다.

- 메서드 이름이 대문자로 시작한다.
  class 이름, namespace 이름, 속성, 메서드는 대문자로 시작하며
  변수는 소문자로 시작한다.
  ex> 배열 길이 반환시 <pre><code>arr.Length</code></pre>

- 접근제한자 디폴트가 private 이다.
  ex> <pre><code>static void Main(string[] args{...} </code></pre> 는 private

- 플랫폼 독립성은 CLI를 구현한 CLR로 가능하고 GC를 통해 메모리를 관리할 수 있다.
  ~소멸자() 도 존재한다.
  ex> C#의 GC 호출 <pre><code>System.GC.Collect();</code></pre>
      Java의 GC 호출 <pre><code>System.gc();</code></pre>

- 지역변수에 var 키워드로 자동 타입지정이 가능하나 선언과 동시에 초기화가 필요하다.

- for-each문 이용시 <pre><code>foreach(var 변수 in 컬렉션){ ... } </code></pre>
  (Java는 for(타입 변수 : 컬렉션){...} )

- List는 인터페이스가 아닌 클래스이며, 리스트 개수는 <pre><code>list.Count</code></pre> 가 반환한다.

- <pre><code>String message;</code></pre> 문자열의 길이는 <pre><code>sizeof(message)</code></pre> 가 반환한다.
  (Java는 <pre><code>message.length();</code></pre> 가 반환)

- 문자열(정수)를 값(정수)로 변경은 <pre><code>int.Parse(문자열)</code></pre> 를 이용하며,
  값(정수)를 문자열(정수)로 변경은 <pre><code>(값).ToString()</code></pre> 을 이용한다.
  (Java는 문자열을 값으로 변경시 <pre><code>Integer.parseInt()</code></pre> 를 이용하며,
  값을 문자열로 변경시 <pre><code>Integer.toString(값)</code></pre> 을 이용한다.)

- 타입 변환시 as 키워드를 이용한다.
  ex> <pre><code>dog as Animal</code></pre>

- 타입은 <pre><code>.GetType()</code></pre> 로 파악 가능하며 is 키워드를 통해 타입비교가 가능하다.
  (Java는 instanceof 키워드를 통해 타입 비교가 가능하다.)

- 문자열을 자를 때 <pre><code>문자열.Split(저장 배열, 옵션)</code></pre>,
  문자열 공백 제거시 <pre><code>문자열.Trim()</code></pre>, <pre><code>문자열.TrimStart()</code></pre>, <pre><code>문자열.TrimEnd()</code></pre>,
  문자열을 합칠 때 <pre><code>문자열배열.Join()</code></pre>

- getter/setter를 속성으로 변환이 가능해져 코드의 양이 줄었다.
  setter 호출 시 <pre><code>Box.Width = 100;</code></pre> 으로 가능하다.
  ex> <pre><code>
	class Box
	{
		private int width;
		public int Width
		{
			get{return width;}
			set{width = value;}
		}
	}</code></pre>

- 상수 선언시 final이 아닌, <pre><code>const</code></pre> 키워드를 이용한다.

- 상속/오버라이딩을 금지하려면 final이 아닌, <pre><code>sealed</code></pre> 키워드를 이용한다.

- SuperClass의 생성자를 명시적으로 호출하려면 SubClass 생성자 뒤에 <pre><code>:base(매개변수)</pre></code>를 사용한다.
  <pre><code>public Child() : base(){...}</pre></code>

- SuperClass와 동일한 이름 메서드를 SubClass가 재정의 한 후, SubClass의 인스턴스가 메서드 호출시
  가까운 것을 택하는 Method Hiding으로 인해 SubClass의 메서드가 호출된다. (오버라이딩 때문이 아님.)

- SuperClass와 동일한 이름 메서드를 SubClass가 재정의 한 후, SubClass의 인스턴스가 메서드 호출시
  Overriding하여 SubClass의 메서드를 호출하려면 <pre><code>virtual</code></pre>, <pre><code>override</code></pre> 키워드를 사용한다.
  ex> Method Hiding
<pre><code>using System;

class Animal{
	public void Eat(){
		Console.WriteLine("냠냠");
	}
}

class Dog : Animal{
	public void Eat(){ // Method Hiding을 명시적으로 하기 위해 new 키워드 사용가능!
		Console.WriteLine("강아지가 사료를 먹는다");
	}
}

class Program{
	static void Main(string[] args){
		Dog dog = new Dog();
		dog.Eat(); // 강아지가 사료를 먹는다.
		((Animal) dog).Eat(); // 냠냠
	}
}</code></pre>
  ex> Method Overriding
<pre><code>using System;

class Animal{
	public virtual void Eat(){
		Console.WriteLine("냠냠");
	}
}

class Dog : Animal{
	public override void Eat(){
		Console.WriteLine("강아지가 사료를 먹는다");
	}
}

class Program{
	static void Main(string[] args){
		Dog dog = new Dog();
		dog.Eat(); // 강아지가 사료를 먹는다.
		((Animal) dog).Eat(); // 강아지가 사료를 먹는다.
	}
}</code></pre>

- SuperClass를 상속받아 메서드를 오버라이딩 할 때, SuperClass가 <pre><code>abstract</code></pre> 키워드를
  갖고 있다면 <pre><code>virtual</code></pre> 키워드는 쓰지 않아야 한다.

### References

- C#프로그래밍, 한빛아카데미, 윤인성

- ASP.NET 게시판 예제
( https://m.blog.naver.com/PostView.nhn?blogId=wow0815&logNo=90179536697&proxyReferer=https%3A%2F%2Fwww.google.co.kr%2F )

- 포트넘버 52468
( http://localhost:52468/ )

- Code First로 ORM 사용

- Razor 구문으로 코드 작성
( http://www.taeyo.pe.kr/Columns/View.aspx?SEQ=442&PSEQ=35&IDX=0 )
