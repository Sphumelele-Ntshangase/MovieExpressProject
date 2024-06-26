
/*
Tipr 4.0.1
Copyright (c) 2018 Tipue
Tipr is released under the MIT License
http://www.tipue.com/tipr
*/


(function($) {

     $.fn.tipr = function(options) {
     
          var set = $.extend( {
               
               'speed'             : 300,
               'mode'              : 'below',
               'marginAbove'       : -65,
               'marginBelow'       : 7,
               'space'             : 70
          
          }, options);

          return this.each(function() {       

               var mouseY = -1;
               $(document).on('mousemove', function(event)
               {
                    mouseY = event.clientY;
               });
               var viewY = $(window).height();

               $(this).hover(
                    function ()
                    {
                         var m = set.mode;
                         var m_a = set.marginAbove;
                         var m_b = set.marginBelow;
 
                         $(window).on('resize', function()
                         {
                              viewY = $(window).height();
                         });
                         
                         if (viewY - mouseY < set.space)
                         {
                              m = 'above';  
                         }
                         else
                         {
                              m = set.mode;
                              
                              if ($(this).attr('data-mode'))
                              {
                                   m = $(this).attr('data-mode') 
                              }                              
                         }

                         if ($(this).attr('data-marginAbove'))
                         {
                              m_a = $(this).attr('data-marginAbove') 
                         }   
                         if ($(this).attr('data-marginBelow'))
                         {
                              m_b = $(this).attr('data-marginBelow') 
                         }                           
 
                         tipr_cont = '.tipr_container_' + m;
                         
                         if (m == 'above')
                         {
                              var out = '<div class="tipr_container_' + m + '" style="margin-top: ' + m_a + 'px;">';
                         }
                         else
                         {
                              var out = '<div class="tipr_container_' + m + '" style="margin-top: ' + m_b + 'px;">';
                         }
                                                  
                         out += '<div class="tipr_point_' + m + '"><div class="tipr_content">' + $(this).attr('data-tip') + '</div></div></div>';
                         
                         $(this).after(out);
                    
                         var w_t = $(tipr_cont).outerWidth();
                         var w_e = $(this).width();
                         var m_l = (w_e / 2) - (w_t / 2);
                    
                         $(tipr_cont).css('margin-left', m_l + 'px');
                         $(this).removeAttr('title alt');
                         
                         $(tipr_cont).fadeIn(set.speed);              
                    },
                    function ()
                    {   
                         $(tipr_cont).remove();    
                    }     
               );             
          });
     };
     
})(jQuery);
