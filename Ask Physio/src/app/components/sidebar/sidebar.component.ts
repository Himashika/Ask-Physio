import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs'; 

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: '/askphysio/dashboard', title: 'Dashboard',  icon: 'design_app', class: 'Patient' },
  // { path: '/askphysio/settings', title: 'Setings',  icon:'loader_gear', class: '' },
  // { path: '/maps', title: 'Maps',  icon:'location_map-big', class: '' },
  // { path: '/askphysio/icons', title: 'icons',  icon:'users_single-02', class: '' },
  { path: '/askphysio/schedule', title: 'schedule',  icon:'objects_key-25', class: 'Consultant' },
  { path: '/askphysio/dashboard-doctor', title: 'Dashboard',  icon:'ui-1_bell-53', class: 'Consultant' }
  

    // { path: '/user-profile', title: 'User Profile',  icon:'users_single-02', class: '' },
    // { path: '/table-list', title: 'Table List',  icon:'design_bullet-list-67', class: '' },
    // { path: '/typography', title: 'Typography',  icon:'text_caps-small', class: '' }
    // { path: '/upgrade', title: 'Upgrade to PRO',  icon:'objects_spaceship', class: 'active active-pro' }

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  userRole = "";

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  let role =  localStorage.getItem("Role");

    forkJoin([role]).subscribe(results => {
      this.userRole = role;
    });

  }
  isMobileMenu() {
      if ( window.innerWidth > 991) {
          return false;
      }
      return true;
  };

  validateUser(role)
  {
 
   if(this.userRole == role)
   {
    return true;
   } 
   else{
    return false;
   }
  }

  validateComponent(type)
  {
   if(this.userRole == type)
   {
    return true;
   } 
   else{
    return false;
   }
  }
  
}
