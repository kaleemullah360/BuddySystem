compile:
	dmcs kaleem.cs

run:
	./kaleem.exe

clean:
	rm -f *.exe

clean-all: 
	rm -f *.o
	rm -f *.exe

view-project:
	firefox https://github.com/kaleemullah360/BuddySystem &

view-profile:
	firefox https://github.com/kaleemullah360 &