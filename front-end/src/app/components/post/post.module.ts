import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostRoutingModule } from './post-routing.module';
import { PostComponent } from './post/post.component';
import { CommentModule } from '../comment/comment.module';

@NgModule({
  declarations: [PostComponent],
  imports: [CommonModule, PostRoutingModule, CommentModule],
  exports: [PostComponent],
})
export class PostModule {}
