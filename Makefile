compile:
	dmcs kaleem.cs

run:
	./kaleem.exe

clean:
	rm -f *.exe

clean-all: 
	rm -f *.o
	rm -f *.exe