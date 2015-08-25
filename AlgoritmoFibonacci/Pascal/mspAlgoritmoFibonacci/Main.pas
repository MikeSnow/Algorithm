program prog;
	{Usamos la libreria Dos que nos permite usar funciones del sistema}
	uses
		Dos;
	var
		{Declaramos la variable opcion para el menu}
		opcion:integer;
	PROCEDURE introducirTeclado(var n:integer);
		{Metodo para introducir por teclado y comprobar si es un numero}
		var
			correcto:integer;
			teclado :string;
		begin
			readln(teclado);
			Val(teclado,n,correcto);
			if (correcto<>0)then
				begin
					writeln('El valor introducido no es un numero');
					n:=-1;
				end
		end;
	PROCEDURE Menu(var n:integer);
		{Menu de la interfaz , dara error si el valor no es correcto}
		begin
			writeln('Escriba el numero del opcion que desee');
			writeln('1--Introducir numero y ejecutar algoritmo');
			writeln('2--Salir');
			introducirTeclado(n);
			if ((n>2)or(n<1))then
				writeln('Error:Introduzca una opcion correcta');
		end;
	PROCEDURE AlgoritmoDeFibonacci;
		var
			{El algoritmo usado , puesto que se pide la sucession es de complejidad O(N), es un bucle for
                en el que vamos sumando el ultimo numero y el anterior exceptuando las dos excepciones que son cuando n es 0
                que la sucession es 0 y cuando n es 1 que la succesion es 1 ,los siguientes son
                n=2 -> 1+0 = 1
                n=3 -> 1+1 = 2;
                n=4 -> 1+2 = 3;
                n=5 -> 2+3 = 5;
                n=6 -> 3+5 = 8;
             }
			n:integer;
			ant_1:Extended;
			ant_2:Extended;
			suma:Extended;
			contador:integer;
			h,m,s,c:Word;
			inicio,final:real;
		begin
			writeln('Introduzca un valor positivo');
			introducirTeclado(n);
			if(	n<0)then
				writeln('Error:Valor introducido incorrecto')
			else
				begin
					{Cojemos el tiempo del sistema}
					GetTime(h,m,s,c);
					inicio:= c/100+s+m*60+h*60*60;
					ant_1:=0;
					ant_2:=1;
					for contador:=0 to n do
						begin
							case (contador) of
								0 : suma:=0;
								1 : suma:=1;
							else
								suma:=ant_1+ant_2;
								ant_1:=ant_2;
								ant_2:=suma;
							end;
							write('->');
							write(suma);
						end;
					GetTime(h,m,s,c);
					final:=c/100+s+m*60+h*60*60;
					writeln();
					write('Tiempo: ');
					write(final-inicio);
					writeln(' segundos');
					{Calculamos el tiempo que ha tardado en hacer todo el programa y lo mostramos por pantalla junto la sucesion de numero}
				end;
		end;
	begin
		repeat
		{Programa principal que dependiendo de la opcion del menu realiza el algoritmo o cierra el programa}
			Menu(opcion);
			if (opcion = 1) then
				AlgoritmoDeFibonacci;
		until (opcion = 2);
	end.
