stseg	segment	para	stack
	dw	16	dup(?)
stseg	ends

dseg	segment	para
string	db	0ah,100	dup('$')
dseg	ends

cseg	segment	para
lab5	proc	far
	assume	cs:cseg,ds:dseg,ss:stseg
	mov	ax,dseg
	mov	ds,ax
	
	mov	cx,99
	lea	bx,string+1
	mov	ah,1
n1:
	int	21h
	mov	[bx],al
	inc	bx
	cmp	al,'.'
	je	ex
	loop	n1
ex:
	mov	ah,9
	lea	dx,string
	int 21h
	
	mov	ah,10h
	int	16h
	
	mov	ax,4c00h
	int	21h
	lab5	endp
cseg	ends
	end	lab5
