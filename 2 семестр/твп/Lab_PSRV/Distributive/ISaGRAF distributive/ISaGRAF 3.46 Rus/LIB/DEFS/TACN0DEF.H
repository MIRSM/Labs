/*
  Name : tacn0def.h
  Target conversions definition file
*/

#ifndef _TACN0DEF_H            /* nested Headers management     */
#define _TACN0DEF_H

#define DIR_INPUT 0            /* direction = input conversion  */
#define DIR_OUTPUT 1           /* direction = output conversion */

typedef int32   T_ANA;         /* integer ANA type              */
typedef float   T_REAL;        /* real ANA type                 */

typedef struct {               /* conversion structure          */
   uint16 number;              /* conversion number (reserved)  */
   uint16 direction;           /* conversion direction          */
   T_REAL *before;             /* value before conversion       */
   T_REAL *after;              /* value after conversion        */
} 
str_cnv;

#define ARG_BEFORE (*(arg->before))
#define ARG_AFTER  (*(arg->after))
#define DIRECTION  (arg->direction)

#endif
/* eof */
