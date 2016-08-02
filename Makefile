compile:
	dmcs buddySystem.cs

run:
	./buddySystem.exe

clean:
	rm -f *.exe

clean-all: 
	rm -f *.o
	rm -f *.exe

view-project:
	firefox https://github.com/kaleemullah360/BuddySystem &

view-profile:
	firefox https://github.com/kaleemullah360 &

ifeq ($(c),)
 c = 'updates'
endif

push:
	git add -A
	git commit -m $(c)
	git push origin master

pull:
	git pull origin master

setup-project:
	sudo bash ./runonce.sh