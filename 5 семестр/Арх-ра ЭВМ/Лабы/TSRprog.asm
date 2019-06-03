code_seg        segment
 TSRprog        proc    far
        assume cs:code_seg
        org     100h
begin:
        mov     cx,72
        lea     si,music
beg:    push    cx
        in      al,61h
        and     al,0ffh-3
        out     61h,al
        mov     al,10110110b
        out     43h, al
        cmp     cx,37
        jae     M2
        dec     si
        dec     si
M2:
        mov     ax,cs:[si]
        cmp     cx,37
        jb      M1
        inc     si
        inc     si
M1:
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
        in      al,61h
        and     al,0ffh-3
        out     61h,al
        mov ax,4c00h
        int  21h
flag    db 0
music   dw      9119,9119,9119,9119,9119,9119,9119,9119,9119,9119,9119,9119
                dw      4559,4304,4062,3835,3620,3416,3224,3043,2873,2711,2559,2415
                dw      9119,9119,9119,9119,9119,9119,9119,9119,9119,9119,9119,9119
index   db 0
TSRprog endp
code_seg        ends
end     begin