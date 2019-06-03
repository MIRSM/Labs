code_seg        segment
 TSRprog        proc    far
        assume cs:code_seg
        org     100h
begin:
        mov     cx,100
        lea     si,music
beg:    push    cx
        in      al,61h
        and     al,0ffh-3
        out     61h,al
        mov     al,10110110b
        out     43h, al
        mov	ax,0000h
		int	16h
		;cmp	ah,48h
		;je	incr
		;cmp ah,50h
		;je decr
		cmp	ah,01h
		je	final
		;mov     ax,cs:[si]
		jmp	play
incr:
	add	cs:[si],100
	mov ax,cs:[si]

	jmp play
decr:
	sub	cs:[si],100
	mov ax,cs:[si]
	jmp play
play:
		out     42h,al
        mov     al,ah
        out     42h,al
        in      al,61h
        or      al,3
        out     61h, al
        in      al,61h
        mov     ax,8600h
        mov     bx,cs
        mov     es,bx
        lea     bx,flag
        mov     cx,7
        mov     dx,0A120h
        int     15h
bue:
        pop     cx
        loop    beg
final:
        mov ax,4c00h
        int  21h
flag    db 0
music   dw      5000
index   db 0
TSRprog endp
code_seg        ends
end     begin